import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.*;

public class Application {
    private static String USERNAME = "aa580e768465da258943e-zone-custom";
    private static String PASSWORD = "aa580e768465da258943e";
    private static String MANGOPROXY_DNS = "43.153.237.55";
    private static int MANGOPROXY_PORT = 2334;
    private static String URL_TO_GET = "http://ip-api.com/json";

    public static void main(String[] args) throws IOException {
        final Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress(MANGOPROXY_DNS, MANGOPROXY_PORT));
        Authenticator.setDefault(
                new Authenticator() {
                    public PasswordAuthentication getPasswordAuthentication() {
                        return new PasswordAuthentication(
                                USERNAME, PASSWORD.toCharArray()
                        );
                    }
                }
        );

        final URL url = new URL(URL_TO_GET);
        final URLConnection urlConnection = url.openConnection(proxy);

        final BufferedReader bufferedReader = new BufferedReader(
                new InputStreamReader(urlConnection.getInputStream()));
        final StringBuilder response = new StringBuilder();

        String inputLine;
        while ((inputLine = bufferedReader.readLine()) != null) {
            response.append(inputLine);
        }
        bufferedReader.close();

        System.out.println(String.format("Response: %s", response.toString()));
    }
}
