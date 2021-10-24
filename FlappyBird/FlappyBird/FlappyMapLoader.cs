using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace FlappyBird
{
    public class FlappyMapLoader
    {
        public static string MapFile { get; set; } = "TestMap.xml";
        public static void LoadOn(List<IFlappyCompound> compounds)
        {
            #region Get a default map to test
            /*Flappymap m = new Flappymap()
            {
                Flappyconfig = new Flappyconfig()
                {
                    Difficulty = new Difficulty()
                    {
                        Integer = 0,
                        Name = "Easy"
                    },
                    Title = "TestLevel",
                    Version = "v1.0.0"
                },
                Map = new Map()
                {
                    Bottom = new Bottom()
                    {
                        Object = new List<Object>()
                        {
                            new Object()
                            {
                                Position = new Position()
                                {
                                    X = 10,
                                    Y = 500
                                },
                                Size = new Size()
                                {
                                    Height = 512,
                                    Width = 128
                                }
                            },
                            new Object()
                            {
                                Position = new Position()
                                {
                                    X = 200,
                                    Y = 500
                                },
                                Size = new Size()
                                {
                                    Height = 512,
                                    Width = 128
                                }
                            }
                        }
                    },
                    Top = new Top()
                    {
                        Object = new List<Object>()
                        {
                            new Object()
                            {
                                Position = new Position()
                                {
                                    X = 10,
                                    Y = 10
                                },
                                Size = new Size()
                                {
                                    Height = 512,
                                    Width = 128
                                }
                            },
                            new Object()
                            {
                                Position = new Position()
                                {
                                    X = 200,
                                    Y = 10
                                },
                                Size = new Size()
                                {
                                    Height = 512,
                                    Width = 128
                                }
                            }
                        }
                    }
                }
            };
            XmlSerializer xs = new XmlSerializer(m.GetType());
            var ms = new MemoryStream();
            xs.Serialize(ms, m);
            File.WriteAllBytes("TestMap.xml", ms.ToArray());
            ms.Dispose();*/
            #endregion
            
            Flappymap map = new MapReader(MapFile).FlappyMap;
            foreach (var @object in map.Map.Bottom.Object)
            {
                AddBotomObject(@object, compounds);
            }
            foreach (var @object in map.Map.Top.Object)
            {
                AddTopObject(@object, compounds);
            }
        }

        private static void AddBotomObject(Object i, List<IFlappyCompound> compounds)
        {
            Tube t = new Tube();
            t.Rectangle.Width = i.Size.Width;
            t.Rectangle.Height = i.Size.Height;
            t.Rectangle.X = i.Position.X;
            t.Rectangle.Y = i.Position.Y;
            t.Rotation = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            compounds.Add(t);
        }
        private static void AddTopObject(Object i, List<IFlappyCompound> compounds)
        {
            Tube t = new Tube();
            t.Rectangle.Width = i.Size.Width;
            t.Rectangle.Height = i.Size.Height;
            t.Rectangle.X = i.Position.X;
            t.Rectangle.Y = i.Position.Y;
            t.Rotation = System.Drawing.RotateFlipType.RotateNoneFlipY;
            compounds.Add(t);
        }
    }
}