FROM node:8-alpine

# WORKDIR /esocial

COPY ["package.json", "package-lock.json", "./"]
RUN apk add --update --no-cache git \
  && npm install --production \
  && apk del git

ENV PORT=3000
EXPOSE 3000

ENV NODE_ENV=production

COPY ./ ./

CMD ["node", "./bin/www"]
