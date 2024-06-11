<?php

$username = 'aa580e768465da258943e-zone-custom';
$password = 'aa580e768465da258943e';
$MANGOPROXY_PORT = 2334;
$MANGOPROXY_DNS = '43.153.237.55';

$urlToGet = 'http://ip-api.com/json';

$ch = curl_init();
curl_setopt($ch, CURLOPT_URL, $urlToGet);
curl_setopt($ch, CURLOPT_HEADER, 0);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
curl_setopt($ch, CURLOPT_PROXYPORT, $MANGOPROXY_PORT);
curl_setopt($ch, CURLOPT_PROXYTYPE, 'HTTP');
curl_setopt($ch, CURLOPT_PROXY, $MANGOPROXY_DNS);
curl_setopt($ch, CURLOPT_PROXYUSERPWD, $username.':'.$password);
$data = curl_exec($ch);
curl_close($ch);

echo $data;
?>
