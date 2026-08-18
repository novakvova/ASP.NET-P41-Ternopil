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
docker build -t webhike-mvc .
docker build --no-cache -t webhike .
docker run -d --restart=always --name webhike-container -p 8096:8080 webhike-mvc

docker tag webhike-mvc:latest novakvova/webhike-mvc:latest
docker push novakvova/webhike-mvc:latest

```