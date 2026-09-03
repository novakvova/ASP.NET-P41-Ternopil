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

## nginx options
```
server {
server_name   p41.itstep.click *.p41.itstep.click;
client_max_body_size 250M;
location / {
        proxy_pass         http://localhost:8054;
        proxy_http_version 1.1;
        proxy_set_header   Upgrade $http_upgrade;
        proxy_set_header   Connection keep-alive;
        proxy_set_header   Host $host;
        proxy_cache_bypass $http_upgrade;
        proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header   X-Forwarded-Proto $scheme;
    }
}

server {
server_name   p41q.itstep.click *.p41q.itstep.click;
client_max_body_size 250M;
location / {
        proxy_pass         http://localhost:2356;
        proxy_http_version 1.1;
        proxy_set_header   Upgrade $http_upgrade;
        proxy_set_header   Connection keep-alive;
        proxy_set_header   Host $host;
        proxy_cache_bypass $http_upgrade;
        proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header   X-Forwarded-Proto $scheme;
    }
}

```