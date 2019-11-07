FROM node:12.13.0-alpine as build-stage

WORKDIR /app
ARG API_URL
ENV REACT_APP_API_URL ${API_URL}

COPY package*.json /app/

RUN npm install

COPY ./ /app/

RUN npm run build

FROM nginx:1.17-alpine

COPY --from=build-stage /app/build/ /usr/share/nginx/html

COPY --from=build-stage /app/config/nginx.conf /etc/nginx/conf.d/default.conf