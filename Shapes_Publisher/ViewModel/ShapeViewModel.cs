using MSMQ.Messaging;
using Newtonsoft.Json;
using Shapes_Publisher.Model;
using Shapes_Publisher.View;
using System.Configuration;

namespace Shapes_Publisher.ViewModel
{
    public class ShapeViewModel
    {
        public ShapeViewModel()
        {
           
        }

        readonly string privateQueuePath = ConfigurationManager.AppSettings["PrivateQueuePath"] ?? "default value";


        public void Publish(System.Windows.Shapes.Shape shape, double x, double y)
        {
            CreateQueue();
            MessageQueue queue = new(privateQueuePath);
            var shapeData = new ShapeModel()
            {
                X = x,
                Y = y,
                Height = shape.Height,
                Width = shape.Width,
                ShapeType = shape.GetType(),
                Stroke = shape.Stroke,
            };
            string message = JsonConvert.SerializeObject(shapeData);
            Message msg = new Message(message);
            queue.Send(msg, "ShapeQueue");

        }


        private void CreateQueue()
        {
            if (!MessageQueue.Exists(privateQueuePath)) MessageQueue.Create(privateQueuePath);
        }

        


    }
}
