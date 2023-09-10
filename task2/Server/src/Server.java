import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;

class Server {
    public static class Extractor {
        public static double[] exctractDoublet(String str) {

            var iterStr = str.split(" ");
            var floats = new double[iterStr.length];
            for (var i = 0; i < iterStr.length; i++) {
                floats[i] = Double.parseDouble(iterStr[i]);
            }
            return floats;
        }

        public static int[] exctractInt(String str) {

            var iterStr = str.split(" ");
            var integers = new int[iterStr.length];
            for (var i = 0; i < iterStr.length; i++) {
                integers[i] = Integer.parseInt(iterStr[i]);
            }
            return integers;
        }
    }

    public static void main(String[] args) {
        ServerSocket server = null;

        try {
            server = new ServerSocket(1001);
            server.setReuseAddress(true);

            while (true) {
                Socket client = server.accept();

                System.out.println("New client connected "
                        + client.getInetAddress()
                        .getHostAddress());

                ClientHandler clientSock
                        = new ClientHandler(client);

                new Thread(clientSock).start();
            }
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (server != null) {
                try {
                    server.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }


    private static class ClientHandler implements Runnable {
        private final Socket clientSocket;

        public ClientHandler(Socket socket) {
            this.clientSocket = socket;
        }

        public void run() {
            PrintWriter out = null;
            BufferedReader in = null;
            try {
                out = new PrintWriter(
                        clientSocket.getOutputStream(), true);

                in = new BufferedReader(
                        new InputStreamReader(
                                clientSocket.getInputStream()));

                String line;
                while ((line = in.readLine()) != null) {
                    System.out.printf(
                            " Sent from the client: %s\n",
                            line);
                    double[] floats;
                    int[] integers;
                    switch (line) {
                        case "Task1":
                            out.println("Enter hypotenuse and side");
                            line = in.readLine();
                            floats = Extractor.exctractDoublet(line);
                            out.println(triangle(floats[0], floats[1]));
                        case "Task2":
                            out.println("Enter your 2 numbers");
                            line = in.readLine();
                            floats = Extractor.exctractDoublet(line);
                            out.println(tripleFunc1(floats[0], floats[1]));
                        case "Task3":
                            out.println("Enter your number");
                            line = in.readLine();
                            integers = Extractor.exctractInt(line);
                            out.println(primeCount(integers[0]));
                        case "Task4":
                            out.println("Enter your 2 numbers");
                            line = in.readLine();
                            floats = Extractor.exctractDoublet(line);
                            out.println(tripleFunc1(floats[0], floats[1]));
                        case "Task5":
                            out.println("Enter hypotenuse and side");
                            int i;
                            while ((i = Integer.parseInt(in.readLine())) >= 0)
                                out.println(i);
                        default:
                            out.println("enter TaskN, where N is a task number");
                    }

                    out.println(line);
                }
            } catch (IOException e) {
                e.printStackTrace();
            } finally {
                try {
                    if (out != null) {
                        out.close();
                    }
                    if (in != null) {
                        in.close();
                        clientSocket.close();
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    public static String triangle(double sideA, double sideB) {
        return "" + Math.sqrt(sideA * sideA + sideB * sideB);
    }

    interface nestedFunc1 {
        double g(double a, double b);
    }

    interface nestedFunc2 {
        double f(double a, double b, double c);
    }

    public static String tripleFunc1(double s, double t) {
        nestedFunc1 result = (a, b) -> (2 * a + b * b) / (a * b * 2 + b * 5);

        return "" + (result.g(12, s) + result.g(t, s) - result.g(2 * s - 1, s * t));
    }

    public static String tripleFunc2(double s, double t) {
        nestedFunc2 result = (a, b, c) -> ((2 * a - b - Math.sin(c)) / (5 + c));

        return "" + (result.f(t, 2 * s, 1.17) + result.f(2.2, t, s - t));
    }


    public static boolean isPrime(int n) {
        return !new String(new char[n]).matches(".?|(..+?)\\1+");
    }

    public static String primeCount(int n) {
        int answer = 0;
        for (int i = 0; i < n; i++) {
            if (isPrime(i)) answer++;
        }
        return "" + answer;
    }

    public static String oricatelniyChlen() {
        int n = 1;
        double answer;
        while ((answer = Math.cos(1 / Math.tan(n))) > 0) n++;
        return "" + answer;
    }
}
