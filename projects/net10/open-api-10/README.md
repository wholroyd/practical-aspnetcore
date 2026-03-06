# Populate XML doc comments into OpenAPI document 

This sample shows how to populate OpenAPI document with metadata from XML doc comments on methods, class, and members.

- ```<summary></summary>``` corresponds to `summary` in OpenAPI.
- ```<remark></remark>``` corresponds to `description` in OpenAPI.
- ```<param name="name">``` corresponds to `parameters[].description` in OpenAPI.
- ```<response code="200"></response>``` corresponds to `responses.200.description` in OpenAPI.
- ```<response code="500"></response>``` corresponds to `responses.500.description` in OpenAPI.

We are using [Scalar](https://scalar.com/) as the API interface.