#!/usr/bin/env bash

export USERNAME=aa580e768465da258943e-zone-custom
export PASSWORD=aa580e768465da258943e
export MANGOPROXY_DNS=43.153.237.55:2334
curl -x http://$USERNAME:$PASSWORD@$MANGOPROXY_DNS http://ip-api.com/json && echo
