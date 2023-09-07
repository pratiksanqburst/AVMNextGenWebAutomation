######  README FILE ######

# AVM Next Gen API Web Automation

This project automates API testing and interaction for the AVM Next Gen system. It consists of three main modules: API Modal, API Requests, and Utils.

## Table of Contents

- [Modules](#modules)
  - [APIModal](#api-modal)
  - [APIRequests](#api-requests)
  - [Utils](#utils)

## Modules

### APIModal

The API Modal module centralizes the definition of all available APIs for the AVM Next Gen system. It includes the following sub-modules:

- Alarm API
- Location API
- ... 

Each sub-module contains the request body and response structure for the corresponding API.

### APIRequests

The API Requests module handles the actual HTTP requests for specific APIs. It uses the API URLs defined in the `APIRequestURLs.cs` file and constructs the requests using the provided request bodies.

### Utils

The Utils module contains utility functions and data required across the project. It includes:

- Request Body Data: Pre-defined request body data for various APIs.
- API URLs (`APIRequestURLs.cs`): A file containing the URLs for different APIs.

