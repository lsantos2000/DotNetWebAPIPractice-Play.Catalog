# Play.Catalog.Service

## Overview

Play.Catalog.Service is a microservice responsible for managing the catalog of items in the Play application. It provides APIs to create, read, update, and delete catalog items.

## Features

- Create new catalog items
- Retrieve catalog items
- Update existing catalog items
- Delete catalog items

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started) (optional, for containerization)

### Installation

1. Clone the repository:

   ```sh
   git clone https://github.com/lsantos2000/https://github.com/lsantos2000/DotNetWebAPIPractice-Play.Catalog.git
   cd Play.Catalog.Service
   ```

2. Restore dependencies:

   ```sh
   dotnet restore
   ```

3. Build the project:
   ```sh
   dotnet build
   ```

### Running the Service

To run the service locally, use the following command:

```sh
dotnet run
```

### Running with Docker

1. Build the Docker image:

   ```sh
   docker build -t play.catalog.service .
   ```

2. Run the Docker container:
   ```sh
   docker run -d -p 5000:80 play.catalog.service
   ```

## API Endpoints

- `GET /items` - Retrieve all catalog items
- `GET /items/{id}` - Retrieve a specific catalog item by ID
- `POST /items` - Create a new catalog item
- `PUT /items/{id}` - Update an existing catalog item
- `DELETE /items/{id}` - Delete a catalog item

## Contributing

Contributions are welcome! Please read the [contributing guidelines](CONTRIBUTING.md) first.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
