# Робота з dotnet
```
dotnet build
dotnet run
dotnet watch

dotnet tool install --global dotnet-ef
dotnet ef migrations add AddIdentityTabels
dotnet ef database update
```

# Build Project

```
docker build -t webqr-api .
docker build --no-cache -t webqr-api .
docker run -d --restart=always --name webqr-api-container -p 8054:8080 webqr-api

docker tag webqr-api:latest novakvova/webqr-api:latest
docker push novakvova/webqr-api:latest

```