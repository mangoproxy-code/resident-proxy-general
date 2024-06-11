const axios = require('axios');
const username = 'aa580e768465da258943e-zone-custom';
const password = 'aa580e768465da258943e';
const MANGOPROXY_DNS = '43.153.237.55';
const MANGOPROXY_PORT = 2334;

axios
  .get('http://ip-api.com/json', {
    proxy: {
      protocol: 'http',
      host: MANGOPROXY_DNS,
      port: MANGOPROXY_PORT,
      auth: {
        username,
        password,
      },
    },
  })
  .then((res) => {
    console.log(res.data);
  })
  .catch((err) => console.error(err));
