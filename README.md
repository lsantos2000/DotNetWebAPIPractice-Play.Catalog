# Play.Catalog

## Overview

Play.Catalog is a microservice responsible for managing the catalog of items in the Play application. It provides APIs to create, read, update, and delete catalog items.

## Features

- Create new catalog items
- Retrieve catalog items
- Update existing catalog items
- Delete catalog items

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started) (optional, for containerization)

## Automated Docker Compose Task

This project includes a Visual Studio or Visual Studio Code task that automatically runs Docker Compose when the solution is loaded. This helps to ensure that all necessary Docker containers are up and running without manual intervention.

The task is defined in the `.vscode/tasks.json` file'.

How It Works

Label: The task is labeled "Run Docker Compose".
Type: The task type is set to "shell", meaning it will execute a shell command.
Command: The command docker-compose -f ./docker-compose.yml up -d is used to start the Docker containers defined in the docker-compose.yml file.
Run Options: The task is configured to run automatically when the folder is opened in Visual Studio Code ("runOn": "folderOpen").

### Installation

1. Clone the repository:

   ```sh
   git clone https://github.com/lsantos2000/DotNetWebAPIPractice-Play.Catalog.git
   cd Play.Catalog
   ```

2. The solution contains two projects.

Play.Catalog uses an in-memory list of catalog items.
PlayDbCatalog uses a MongoDB. Switch to the one you want to run. You can run one at a time.

3. Follow the README instructions under that project. Eventually, try the second one.

```sh
 cd Play.Catalog
 cd /src/Play.Catalog.Service
 open README.md
```

or

```sh
 cd Play.Catalog
 cd /src/Play.DbCatalog.Service
 open README.md
```

### API Endpoints

GET /items - Retrieve all catalog items
GET /items/{id} - Retrieve a specific catalog item by ID
POST /items - Create a new catalog item
PUT /items/{id} - Update an existing catalog item
DELETE /items/{id} - Delete a catalog item
Contributing
Contributions are welcome! Please read the contributing guidelines first.

7. License

This project is licensed under the MIT License. See the LICENSE file for details.

```

```
