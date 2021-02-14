#! /usr/bin/env node
var shell = require("shelljs");

var dockerRun = require("./docker-build");
var helmRun = require("./helm-run");

shell.exec(dockerRun && helmRun);