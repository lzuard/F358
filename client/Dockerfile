FROM node:24.11.0 AS base
WORKDIR /app
COPY package.json .
COPY package-lock.json .
COPY vite.config.ts .
RUN npm install
COPY . .
EXPOSE 8888
CMD ["npm", "run", "dev", "--", "--host"]