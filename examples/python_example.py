#!/usr/bin/env python3

import requests

username = "aa580e768465da258943e-zone-custom"
password = "aa580e768465da258943e"
MANGOPROXY_DNS = "43.153.237.55:2334"
urlToGet = "http://ip-api.com/json"
proxy = {"http":"http://{}:{}@{}".format(username, password, MANGOPROXY_DNS)}
r = requests.get(urlToGet , proxies=proxy)

print("Response:{}".format(r.text))
