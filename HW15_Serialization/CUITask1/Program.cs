using System;
using System.Collections.Generic;
using CUITask1.Entities;
using CUITask1.Enums;
using Newtonsoft.Json;

namespace CUITask1
{
    internal static class Program
    {
        private static readonly Random Rnd = new Random();

        /// <summary>
        ///     Генерация рандомного значения enum
        /// </summary>
        /// <typeparam name="TEnum">Какой-либо Enum</typeparam>
        /// <returns>Рандомное значение Enum</returns>
        private static TEnum RandomEnumValue<TEnum>() where TEnum : Enum
        {
            var values = Enum.GetValues(typeof(TEnum));
            return (TEnum) values.GetValue(Rnd.Next(values.Length));
        }

        /// <summary>
        ///     Генерация рандомного IP адресса
        /// </summary>
        /// <returns></returns>
        private static string RandomIpAddress()
        {
            return $"{Rnd.Next(1, 255)}.{Rnd.Next(0, 255)}.{Rnd.Next(0, 255)}.{Rnd.Next(0, 255)}";
        }

        /// <summary>
        ///     Генерация рандомного списка серверных маркеров
        /// </summary>
        /// <param name="count">Количество генерируемых серверов</param>
        /// <param name="markerCount">Количество генерируемых маркеров</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static IEnumerable<ServerMarker> GenerateServerMarkers(int count = 5, int markerCount = 5)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));
            var result = new List<ServerMarker>(count);
            for (var i = 0; i < result.Capacity; i++)
                result.Add(new ServerMarker
                {
                    Address = RandomIpAddress(),
                    Markers = GenerateMarkers(markerCount)
                });
            return result;
        }

        /// <summary>
        ///     Генерация маркеров
        /// </summary>
        /// <param name="count">Количество генерируемых маркеров</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static IEnumerable<Marker> GenerateMarkers(int count = 5)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));
            var result = new List<Marker>(count);
            for (var i = 0; i < result.Capacity; i++)
                result.Add(new Marker
                {
                    Title = $"Marker #{i}",
                    Coordinates = new MarkerCoordinate
                    {
                        X = Rnd.Next(0, 100),
                        Y = Rnd.Next(0, 100),
                        Z = Rnd.Next(0, 100)
                    },
                    Size = RandomEnumValue<MarkerSize>(),
                    Type = RandomEnumValue<MarkerType>()
                });

            return result;
        }

        private static void Main()
        {
            //Маркеры
            var markers = GenerateMarkers();
            //Маркеры сервера
            var serverMarkers = GenerateServerMarkers(1, 2);
            //Карта
            var map = new Map
            {
                Name = "SomeMap",
                Global = markers,
                ServerMarkers = serverMarkers
            };

            //Сериализация
            var mapJsonResult = JsonConvert.SerializeObject(map, Formatting.Indented);
            var markersJsonResult = JsonConvert.SerializeObject(markers, Formatting.Indented);
            var serverMarkersJsonResult = JsonConvert.SerializeObject(serverMarkers, Formatting.Indented);

            //Вывод в консоль результатов
            Console.WriteLine("Маркеры:");
            Console.WriteLine(markersJsonResult);
            ConsoleWait();

            Console.WriteLine("Маркеры сервера:");
            Console.WriteLine(serverMarkersJsonResult);
            ConsoleWait();

            Console.WriteLine("Маркеры карты:");
            Console.WriteLine(mapJsonResult);
            ConsoleWait();
        }

        private static void ConsoleWait()
        {
            Console.WriteLine("Нажмите любую клавишу:");
            Console.ReadKey();
            Console.Clear();
        }
    }
}