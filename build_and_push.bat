@echo off

REM ==== WEB ====
cd WebReactQRCode
docker build -t qr-react --build-arg VITE_SERVER_URL=https://p41.itstep.click .
docker tag qr-react:latest novakvova/qr-react:latest
docker push novakvova/qr-react:latest

REM ==== API ====
cd ..\WebQRCode
docker build -t webqr-api .
docker tag webqr-api:latest novakvova/webqr-api:latest
docker push novakvova/webqr-api:latest

echo DONE
pause
