﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace EF_Core_postgres2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
//    1. Переделайте тип Id записей в таблице на Guid
//2. Выполните первичную миграцию(Code First)
//3. Добавьте в БД таблицу с дисциплинами(предметами) по Code First
//4. Реализуйте функционал редактирования списка предметов
//5. Добавьте возможность указывать предмет в таблице посещаемости студентов(пока достаточно только ID)

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                await db.Students.AddAsync(new Student { Id = Guid.NewGuid(), Name = studentsTexbox.Text });
                db.SaveChanges();
                MessageBox.Show($"Информация успешно добавлена");
            }
        }

        private async void buttunSubjekt_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                await db.Subjects.AddAsync(new Subject  { Id = Guid.NewGuid(), Name = subjectTextbox.Text });
                db.SaveChanges();
                MessageBox.Show($"Информация успешно добавлена2");
            }

        }

        private async void buttonVisit_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                await db.Visits.AddAsync(new Visit { Id = Guid.NewGuid(), Date = visitTextbox.Text });
                db.SaveChanges();
                MessageBox.Show($"Информация успешно добавлена3");
               
            }
        }

        private void ButtonList_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                var list = db.Visits.Include(it => it.Student).
                    Include(it =>it.Subject).ToList();
                listBox.ItemsSource = list;
                MessageBox.Show($"OK");
            }

        }
    }
}
