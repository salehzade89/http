using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace HttpServer {
    internal class Program {
        private static void Main(string[] args) {
            var listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:5000/");
            listener.Start();

            while (true) {
                var context = listener.GetContext();
                var output = context.Response.OutputStream;
                var writer = new StreamWriter(output);
                var req = context.Request;
                object data = "No data";
                if (req.Url.Segments[1].Contains("developers")) {
                    data = new string[] {
                        "Shafag", "Zulfugar",
                        "Javid", "Oqtay", "Alim"
                    };
                } else if (req.Url.Segments[1].Contains("designers")) {
                    if (req.Url.Segments[2].Contains("fake")) {
                        data = new string[] {
                            "Sasha"
                        };
                    } else if (req.Url.Segments[2].Contains("actual")) {
                        data = new string[] {
                            "Elkhan", "Isa", "Nadir"
                        };
                    }

                }
                writer.WriteLine(JsonConvert.SerializeObject(data));
                writer.Close();
                context.Response.StatusCode = 200;
                context.Response.Close();






                //var context = listener.GetContext();
                //if (context.Request.HttpMethod.ToUpper() != "POST") {
                //    Console.WriteLine("not post");
                //    context.Response.StatusCode = 404;
                //    context.Response.Close();
                //    continue;
                //}
                //if (context.Request.ContentLength64 == 0) {
                //    Console.WriteLine("no data");
                //    context.Response.StatusCode = 403;
                //    context.Response.Close();
                //    continue;
                //}
                //var stream = context.Request.InputStream;
                //var reader = new StreamReader(stream);
                //var str = reader.ReadLine();
                //var msg = JsonConvert.DeserializeObject<MessageItem>(str);
                //if (msg == null) {
                //    Console.WriteLine("invalid data");
                //    context.Response.StatusCode = 403;
                //    context.Response.Close();
                //    continue;
                //}
                //Console.WriteLine($"{msg.Name}: {msg.Message}");

                //var output = context.Response.OutputStream;
                //var writer = new StreamWriter(output);
                //var data = new {
                //    Result = "MessageProcessed",
                //    StatusCode = 200,
                //    OperationTime = DateTime.Now
                //};
                //writer.WriteLine(JsonConvert.SerializeObject(data));
                //writer.Close();
                //context.Response.StatusCode = 200;
                //context.Response.Close();
            }
        }
    }
}