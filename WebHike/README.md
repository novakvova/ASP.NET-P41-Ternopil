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
docker run -d --restart=always --name webhike-container -p 8096:8080 webhike-mvc
```