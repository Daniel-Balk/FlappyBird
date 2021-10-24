using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace FlappyBird
{
    public class MapReader
    {
        #region Loader
        public MapReader(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Flappymap));
            var xml = File.ReadAllText(file);
            using (StringReader reader = new StringReader(xml))
            {
                var mp = (Flappymap)serializer.Deserialize(reader);
                FlappyMap = mp;
            }
        }
        #endregion
        public Flappymap FlappyMap { get; set; }
    }

    #region Declaration
    [XmlRoot(ElementName = "difficulty")]
    public class Difficulty
    {

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "integer")]
        public int Integer { get; set; }
    }
    [XmlRoot(ElementName = "flappyconfig")]
    public class Flappyconfig
    {

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "difficulty")]
        public Difficulty Difficulty { get; set; }

        [XmlElement(ElementName = "version")]
        public string Version { get; set; }
    }
    [XmlRoot(ElementName = "position")]
    public class Position
    {

        [XmlElement(ElementName = "x")]
        public int X { get; set; }

        [XmlElement(ElementName = "y")]
        public int Y { get; set; }
    }
    [XmlRoot(ElementName = "size")]
    public class Size
    {

        [XmlElement(ElementName = "width")]
        public int Width { get; set; }

        [XmlElement(ElementName = "height")]
        public int Height { get; set; }
    }
    [XmlRoot(ElementName = "object")]
    public class Object
    {

        [XmlElement(ElementName = "position")]
        public Position Position { get; set; }

        [XmlElement(ElementName = "size")]
        public Size Size { get; set; }
    }
    [XmlRoot(ElementName = "top")]
    public class Top
    {

        [XmlElement(ElementName = "object")]
        public List<Object> Object { get; set; }
    }
    [XmlRoot(ElementName = "bottom")]
    public class Bottom
    {

        [XmlElement(ElementName = "object")]
        public List<Object> Object { get; set; }
    }
    [XmlRoot(ElementName = "map")]
    public class Map
    {

        [XmlElement(ElementName = "top")]
        public Top Top { get; set; }

        [XmlElement(ElementName = "bottom")]
        public Bottom Bottom { get; set; }
    }
    [XmlRoot(ElementName = "flappymap")]
    public class Flappymap
    {

        [XmlElement(ElementName = "flappyconfig")]
        public Flappyconfig Flappyconfig { get; set; }

        [XmlElement(ElementName = "map")]
        public Map Map { get; set; }
    }
    #endregion
}