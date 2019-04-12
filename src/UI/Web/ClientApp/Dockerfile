FROM nginx:alpine
COPY src/UI/Web/ClientApp/nginx.conf /etc/nginx/nginx.conf
RUN rm -rf /usr/share/nginx/html/*
COPY src/UI/Web/ClientApp/dist/ClientApp/* /usr/share/nginx/html/
WORKDIR /usr/share/nginx/html
COPY src/UI/Web/ClientApp/dist/ .
