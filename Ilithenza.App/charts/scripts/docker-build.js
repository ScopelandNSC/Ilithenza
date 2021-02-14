#! /usr/bin/env node
const shell = require("shelljs");
const fs = require('fs');

fs.copyFileSync('.dockerignore', '../.dockerignore');
console.log('copied .dockerignore to parent directory');

shell.exec(`docker build -t "resdiary-on.azurecr.io/resdiary/resdiary-webapp:local" -f "./src/Dockerfile" ..`);

fs.unlinkSync('../.dockerignore');