using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace FlappyBird
{
    public delegate void ComponentAdding(IFlappyCompound component);
    public class FlappyMapLoader
    {
        public static string MapFile { get; set; } = "TestMap.xml";
        public static void LoadOn(ComponentAdding add)
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
                AddBotomObject(@object, add);
            }
            foreach (var @object in map.Map.Top.Object)
            {
                AddTopObject(@object, add);
            }
        }

        private static void AddBotomObject(Object i, ComponentAdding add)
        {
            Tube t = new Tube();
            t.Rotation = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            t.Rectangle = new System.Drawing.Rectangle()
            {
                Height = i.Size.Height,
                Width = i.Size.Width,
                X = i.Position.X,
                Y = i.Position.Y
            };
            add(t);
        }
        private static void AddTopObject(Object i, ComponentAdding add)
        {
            Tube t = new Tube();
            t.Rotation = System.Drawing.RotateFlipType.RotateNoneFlipY;
            t.Rectangle = new System.Drawing.Rectangle()
            {
                Height = i.Size.Height,
                Width = i.Size.Width,
                X = i.Position.X,
                Y = i.Position.Y
            };
            add(t);
        }
    }
}