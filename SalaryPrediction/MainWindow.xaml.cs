﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using RDotNet;
using System.IO;

namespace SalaryPrediction
{
    public partial class MainWindow : Window
    {
        public string[] prof = { "All", "Вспомогательная и дополнительная транспортная  деятельность", "Высшее профессиональное образование. Образование для взрослых и прочие виды образование", "Деятельность водного транспорта", "Деятельность воздушного и космического транспорта", "Деятельность другого  сухопутного транспорта", "Деятельность железнодорожного транспорта", "Деятельность по организации отдыха и развлечений, культуры и  спорта", "Добыча каменного угля, бурого угля и торфа; добыча урановой и ториевой руд", "Добыча сырой нефти и природного газа; предоставление услуг в этих областях", "Дошкольное и начальное общее образование.Основное общее, среднее (полное) общее, начальное и среднее профессиональное образование", "Издательская и полиграфическая деятельность, тиражирование  записанных носителей информации", "Металлургическое производство", "Научные исследования и разработки", "Операции с недвижимым имуществом, аренда, услуги по информационным технологиям и прочие услуги", "Подраздел DA Производство пищевых продуктов, включая напитки, и табака", "Подраздел DB Текстильное и швейное производство", "Подраздел DC Производство кожи, изделий из кожи и производство обуви", "Подраздел DD Обработка древесины и производство изделий из дерева", "Подраздел DE Целлюлозно - бумажное производство; издательская и полиграфическая деятельность", "Подраздел DI Производство прочих неметаллических минеральных продуктов", "Подраздел DJ Металлургическое производство и производство готовых металлических изделий", "Подраздел DL Производство электрооборудования, электронного и оптического оборудования", "Подраздел DM Производство транспортных средств и  оборудования", "Подраздел DN Прочие производства", "Подраздел СА Добыча топливно-энергетических полезных ископаемых", "Подраздел СВ Добыча полезных ископаемых, кроме топливно-энергетических", "Производство готовых металлических изделий", "Производство других пищевых продуктов, табачных изделий", "Производство другого электрооборудования, электронного иоптического оборудования", "Производство и распределение газообразного топлива, пара и горячей воды; сбор, очистка и распределение воды", "Производство молочных продуктов", "Производство мяса и мясопродуктов", "Производство одежды; выделка и крашение меха", "Производство хлеба и мучных кондитерских изделий недлительного хранения", "Производство целлюлозы, древесной массы, бумаги, картона и  изделий из них", "Производство электрических машин и электрооборудования", "Производство, передача и распределение электроэнергии", "Раздел D Обрабатывающие производства", "Раздел F Строительство", "Раздел G Оптовая и розничная торговля; ремонт автотранспортных средств, мотоциклов, бытовых изделий и предметов личного пользования", "Раздел I Транспорт и связь", "Раздел I1 Транспорт", "Раздел K Операции с недвижимым имуществом, аренда и предоставление услуг", "Раздел M Образование", "Раздел N Здравоохранение и предоставление социальных  услуг", "Раздел Е Производство и распределение электроэнергии, газа и воды", "Раздел Н Гостиницы и рестораны", "Раздел С Добыча полезных ископаемых", "Связь", "Текстильное производство" };
        public string[] reg = { "Алтайский край", "Амурская область", "Архангельская область", "Астраханская область", "Белгородская область", "Владимирская область", "Волгоградская область", "Вологодская область", "Воронежская область", "г.Санкт-Петербург", "Еврейская автономная область", "Забайкальский край", "Ивановская область", "Иркутская область", "Кабардино-Балкарская Республика", "Калининградская область", "Калужская область", "Камчатский край", "Карачаево-Черкесская Республика", "Кемеровская область", "Кировская область", "Костромская область", "Краснодарский край", "Красноярский край", "Курганская область", "Курская область", "Ленинградская область", "Липецкая область", "Магаданская область", "Московская область", "Мурманская область", "Нижегородская область", "Новгородская область", "Новосибирская область", "Омская область", "Оренбургская область", "Орловская область", "Пензенская область", "Пермский край", "Приволжский федеральный округ", "Приморский край", "Псковская область", "Республика Адыгея", "Республика Алтай", "Республика Башкортостан", "Республика Бурятия", "Республика Дагестан", "Республика Ингушетия", "Республика Калмыкия", "Республика Карелия", "Республика Марий Эл", "Республика Мордовия", "Республика Саха(Якутия)", "Республика Северная Осетия - Алания", "Республика Татарстан", "Республика Тыва", "Республика Хакасия", "Российская Федерация", "Ростовская область", "Рязанская область", "Самарская область", "Саратовская область", "Сахалинская область", "Свердловская область", "Северо-Западный федеральный округ", "Северо-Кавказский федеральный округ", "Сибирский федеральный округ", "Смоленская область", "Ставропольский край", "Тамбовская область", "Тверская область", "Томская область", "Тульская область", "Тюменская область", "Удмуртская Республика", "Ульяновская область", "Уральский федеральный округ", "Хабаровский край", "Центральный федеральный округ", "Челябинская область", "Чувашская Республика", "Южный федеральный округ(по 2009 год)", "Ярославская область", "Брянская область", "г.Москва", "Дальневосточный федеральный округ", "Ненецкий авт.округ", "Республика Коми", "Ханты-Мансийский автономный округ-Югра", "Чукотский автономный округ", "Ямало-Ненецкий автономный округ" };
        public List<ComboData> Region = new List<ComboData>();
        public List<ComboData> Professions = new List<ComboData>();
        public class ComboData
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
            RdotNetCaller rdotNetCaller = new RdotNetCaller("Salary.R");
            for (int i = 0; i < prof.Length; i++)
            {
                Professions.Add(new ComboData { Id = i+1, Value = prof[i]});
            }
            ComboBoxProfession.ItemsSource = Professions;
            ComboBoxProfession.DisplayMemberPath = "Value";
            ComboBoxProfession.SelectedValuePath = "Id";
            for (int i = 0; i < reg.Length; i++)
            {
                Region.Add(new ComboData { Id = i+1, Value = reg[i]});
            }
            ComboBoxRegion.ItemsSource = Region;
            ComboBoxRegion.DisplayMemberPath = "Value";
            ComboBoxRegion.SelectedValuePath = "Id";
        }

        public bool CheckTextBoxes()
        {
            return ComboBoxRegion.Text.Length != 0 && ComboBoxSex.Text.Length != 0 &&
                    ComboBoxProfession.Text.Length != 0;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxSex.Text = string.Empty;
            ComboBoxRegion.Text = string.Empty;
            ComboBoxProfession.Text = string.Empty;
            labelResult.Content = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var first = 1;
            foreach (var item in Professions)
            {
                if (item.Value == ComboBoxProfession.Text)
                {
                    first = item.Id;
                }
            }
            var second = 3;
            if (ComboBoxSex.Text == "мужчины")
            {
                second = 2;
            }
            else if(ComboBoxSex.Text == "All")
            {
                second = 1;
            }
            var third = 1;
            foreach (var item in Region)
            {
                if (item.Value == ComboBoxRegion.Text)
                {
                    third = item.Id;
                }
            }
            StartupParameter rinit = new StartupParameter();
            RdotNetCaller rdotNetCaller = new RdotNetCaller("Salary.R");
            if (!CheckTextBoxes())
                MessageBox.Show("Введены не все значения параметров!!!");
            else
            {
                var result = rdotNetCaller.CallMyModel(first.ToString(), second.ToString(), third.ToString()).Replace('.', ',');
                var convertedResult = Convert.ToDouble(result);
                var roundedResult = Math.Round(convertedResult, 2);
                result = roundedResult.ToString();
                labelResult.Content = string.Format("Ваша прогнозируемая зарплата: {0} рублей", result);
            }
        }
    }
}
