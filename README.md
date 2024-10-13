# Multi-Service .NET 8 Application

This project is a multi-service web application that includes:
1. **API Service**: A .NET 8 Web API for fetching weather data.
2. **MongoDB**: A database service to store weather data.
3. **Redis**: A caching service to improve API response times.

The application is containerized using Docker, and you can set up a CI/CD pipeline with Azure DevOps or use AWS EC2 as a self-hosted agent.

## Prerequisites

To run and deploy this project, you need:
- **.NET 8 SDK**: [Download Here](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Docker**: [Download Here](https://www.docker.com/products/docker-desktop)
- **Git**: [Download Here](https://git-scm.com/downloads)

Optional for CI/CD:
- **Azure DevOps Account**
- **AWS EC2 instance** (if using as self-hosted agent for CI/CD)

---

## Local Setup

### 1. Clone the Repository

```bash
git clone https://github.com/<your-username>/<your-repository-name>.git
cd <your-repository-name>
```

## 2. Run the Application Using Docker Compose

Run the following command to start all services (API, MongoDB, Redis):

```bash
docker-compose up --build
```

This command will:
- Build the API service.
- Start MongoDB and Redis containers.
- Expose the API on `http://localhost:8080`.

## 3. Test the API

You can now test the API by fetching weather data by location using `curl` or Postman. For example:

```bash
GET http://localhost:8080/Weather/reset-cache/{locationId}
for example
curl http://localhost:8080/Weather/1
```

### Reset Cache API

To reset the cache for a specific location, use the following endpoint:

```bash
POST http://localhost:8080/Weather/reset-cache/{locationId}
for example
curl http://localhost:8080/Weather/reset-cache/1
```
