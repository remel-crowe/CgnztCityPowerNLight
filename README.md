# Cognizant Dataverse Application

## Overview

This project is a C# application that demonstrates the creation, retrieval, updating, and deletion of entities in a Microsoft Dataverse environment. The application connects to Dataverse using a service client and performs various operations on `Account`, `Contact`, and `Incident` entities.

## Features

- Create, retrieve, update, and delete `Account`, `Contact`, and `Incident` entities.
- Display entity details in the console.
- Utility methods for interacting with entities.

## Prerequisites

- .NET SDK
- Microsoft Dataverse environment
- Configuration for Dataverse connection (AppId, SecretId, InstanceUri)

## Configuration

Ensure the following environment variables are set in your configuration file (e.g., `appsettings.json`):

```json
{
  "Dataverse": {
    "AppId": "your-app-id",
    "SecretId": "your-secret-id",
    "InstanceUri": "https://your-instance.crm.dynamics.com"
  }
}
```

## Usage

1. Clone the repository:

```sh
git clone https://github.com/your-repo/cognizant-dataverse-app.git
cd cognizant-dataverse-app
```

2. Build the project:

```sh
dotnet build
```

3. Run the application:

```sh
dotnet run
```

## Project Structure

- `App/CustomerServiceHubApp.cs`: Main application class demonstrating entity operations.
- `Model/Entities/Contact.cs`: Entity class for `Contact`.
- `Utilities/DataverseServiceClientConnection.cs`: Utility class for connecting to Dataverse.
- `Utilities/EntityUtils.cs`: Utility class for displaying entity details.

## Key Classes and Methods

### CustomerServiceHub

Handles the main operations for creating, retrieving, updating, and deleting entities.

### DataverseServiceClientConnection

Connects to the Dataverse environment using the provided configuration.

### EntityUtils

Provides methods to display entity details in the console.

## Example

Here is an example of how to create and display an `Account` entity:

```csharp
var accountService = new AccountService(dataverseConnection);
var demoAccount = new Account
{
    Name = "Big X Corp",
    Telephone1 = "1234567890",
    Address1_City = "Houston",
    EMailAddress1 = "mail@bigXcorp.com",
};

demoAccount.Id = CreateEntity(accountService, demoAccount);
EntityUtils.DisplayEntity(demoAccount);
```

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.