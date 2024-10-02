# Docker Compose Setup for MongoDB and RabbitMQ

This project provides a Docker Compose setup to run MongoDB and RabbitMQ services. It includes configurations for persistent storage using Docker volumes.

## Services

- **MongoDB**: A NoSQL database.
- **RabbitMQ**: A message broker with a management interface.

## Prerequisites

- Docker
- Docker Compose

## Usage

1. Clone the repository:

   ```sh
   git https://github.com/lsantos2000/https://github.com/lsantos2000/DotNetWebAPIPractice-Play.Catalog.git
   cd <repository-directory>
   ```

2. Start the services:

   ```sh
   docker-compose up -d
   ```

3. Access the services:
   - MongoDB: `mongodb://localhost:27017`
   - RabbitMQ Management Interface: `http://localhost:15672` (default username: `guest`, password: `guest`)

## Volumes

- `mongodbdata`: Stores MongoDB data.
- `rabbitmqdata`: Stores RabbitMQ data.

## Stopping the Services

To stop the services, run:

```sh
docker-compose down
```

### Notes

Instead of the docker-compose file, to run MongoDB locally with the data stored in `/data/db`, you can use the following Docker command:

```sh
docker run -d -p 27017:27017 -v ./data/db:./data/db --name mongodb mongo
```

Here's a breakdown of the command:

- `docker run`: Runs a new container.
- `-d`: d for 'detached' runs the container in detached mode (in the background).
- `-p 27017:27017`: p for 'map' maps port 27017 on your local machine to port 27017 in the container.
- `-v ./data/db:./data/db`: v for 'volume' mounts the local directory `/data/db` to `/data/db` in the container for data persistence.
- `--name mongodb`: Names the container [`mongodb`]
- `mongo`: Uses the official MongoDB image from Docker Hub.

Make sure the `/data/db` directory exists on your local machine before running the command. You can create it using:

```sh
mkdir -p /data/db
```

### Utilities

Go to VS Code Extensions > Install MongoDb for VS Code extension
