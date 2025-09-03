Write-Host "Upgrading all .csproj files to net10.0 and LangVersion preview..."
$csprojs = Get-ChildItem -Path "$PSScriptRoot\..\projects" -Recurse -Filter *.csproj
$updated = 0
foreach($f in $csprojs){
    $content = Get-Content -Raw -LiteralPath $f.FullName
    $original = $content
    # Update TargetFramework and TargetFrameworks occurrences for net6/7/8/9 to net10.0
    $content = $content -replace '<TargetFramework>net(6|7|8|9)\.0</TargetFramework>', '<TargetFramework>net10.0</TargetFramework>'
    $content = $content -replace '(?<=<TargetFrameworks>)([^<]+)', { param($m) ($m.Value -replace 'net(6|7|8|9)\.0','net10.0') }
    # Ensure LangVersion preview present in first PropertyGroup
    if($content -notmatch '<LangVersion>'){
        $content = [regex]::Replace($content,'(<PropertyGroup[^>]*>)([\s\S]*?)(</PropertyGroup>)',{
            param($m)
            if($script:inserted){ return $m.Value }
            $script:inserted = $true
            $pgOpen = $m.Groups[1].Value
            $pgBody = $m.Groups[2].Value
            $pgClose = $m.Groups[3].Value
            # Try to place after ImplicitUsings if exists
            if($pgBody -match '<ImplicitUsings>.*?</ImplicitUsings>'){
                return ($pgOpen + ($pgBody -replace '(</ImplicitUsings>)','$1`n    <LangVersion>preview</LangVersion>') + $pgClose)
            } else {
                return ($pgOpen + $pgBody + "    <LangVersion>preview</LangVersion>`n" + $pgClose)
            }
        },1)
    } else {
        # Normalize existing LangVersion to preview
        $content = $content -replace '<LangVersion>.*?</LangVersion>','<LangVersion>preview</LangVersion>'
    }
    if($content -ne $original){
        Set-Content -LiteralPath $f.FullName -Value $content -Encoding UTF8
        $updated++
        Write-Host "Updated: $($f.FullName)"
    }
}
Write-Host "Completed. Updated $updated project files." 