FROM node:lts AS base
WORKDIR /app
COPY package.json .
COPY package-lock.json .
COPY vite.config.ts .
RUN npm install
COPY . .
EXPOSE 5173
CMD ["npm", "run", "dev", "--", "--host"]