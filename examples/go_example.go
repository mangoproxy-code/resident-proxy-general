package main

import (
    "net/url"
    "net/http"
    "fmt"
    "io/ioutil"
    "os"
)

const (
    proxyUrlTemplate = "http://%s:%s@%s:%s"
    username = "aa580e768465da258943e-zone-custom"
    password = "aa580e768465da258943e"
    MANGOPROXY_DNS = "43.153.237.55"
    MANGOPROXY_PORT = "2334"
    urlToGet = "http://ip-api.com/json"
)

func main() {
    proxy := fmt.Sprintf(proxyUrlTemplate, username, password, MANGOPROXY_DNS, MANGOPROXY_PORT)
    proxyURL, err := url.Parse(proxy)
    if err != nil {
        fmt.Printf("failed to form proxy URL: %v", err)
        os.Exit(1)
    }

    u, err := url.Parse(urlToGet)
    if err != nil {
        fmt.Printf("failed to form GET request URL: %v", err)
        os.Exit(1)
    }

    transport := &http.Transport{Proxy: http.ProxyURL(proxyURL)}
    client := &http.Client{Transport: transport}
    request, err := http.NewRequest("GET", u.String(), nil)
    if err != nil {
        fmt.Printf("failed to form GET request: %v", err)
        os.Exit(1)
    }

    response, err := client.Do(request)
    if err != nil {
        fmt.Printf("failed to perform GET request: %v", err)
        os.Exit(1)
    }

    responseBodyBytes, err := ioutil.ReadAll(response.Body)
    if err != nil {
        fmt.Printf("could not read response body bytes: %v", err)
        os.Exit(1)
    }
    fmt.Printf("Response: %s ", string(responseBodyBytes))
}
