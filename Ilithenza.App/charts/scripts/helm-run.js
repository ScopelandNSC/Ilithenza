#! /usr/bin/env node
var shell = require("shelljs");

shell.exec(`helm upgrade resdiary-webapp "./charts/resdiary-webapp" -f "./charts/resdiary-webapp/values.local.yaml" --install --namespace default`);