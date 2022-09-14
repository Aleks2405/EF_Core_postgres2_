using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;
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
    
//1 Добавьте группы для студентов
//2 Добавьте навигационное свойство к студенту, ведущее на группу студента
//3 Добавьте обратное навигационное свойство в группу, которое позволит получить всех студентов из группы
//4 Заполните группы тестовыми данными
//5 Выполните запрос через EF, возвращающий все группы с заполненными студентами
//6 * Реализуйте запрос на EF, который выведет всех студентов, посетивших любой предмет в сентябре 2022 г.
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //if (aq == null)
            //{
            //    button.IsEnabled = false;
            //}
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                await db.Students.AddAsync(new Student
                {
                    Id = Guid.NewGuid(),
                    Name = studentsTexbox.Text,
                    Groupp = aq 
                   
                }) ;
                
               await db.SaveChangesAsync();
                MessageBox.Show($"Информация успешно добавлена");

            }
        }

        private async void buttunSubjekt_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                await db.Subjects.AddAsync(new Subject  { Id = Guid.NewGuid(), Name = subjectTextbox.Text });
                await db.SaveChangesAsync();
                MessageBox.Show($"Информация успешно добавлена2");
            }

        }

        private async void buttonVisit_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                await db.Visits.AddAsync(new Visit { Id = Guid.NewGuid(), Date = visitTextbox.Text });
                await db.SaveChangesAsync();
                MessageBox.Show($"Информация успешно добавлена3");              
            }
        }
        private async void ButtonList_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {    ///
                //var list = await db.Visits.Include(it => it.Student).  
                //    Include(it =>it.Subject).ToListAsync();
                // listBox.ItemsSource = list; 
                //MessageBox.Show($"OK");
                // var g = await db.Groups.ToListAsync();
                // var list = await db.Students.Include(it => it.Groupp).ToListAsync();
                //// list.ForEach(it => it.Groupp = g[Random.Shared.Next(0, g.Count - 1)]);
                //list.ForEach(it => it.Groupp = g.First());  // добавить поле которое покажет какая группа была добавлена первая и последняя
                // await db.SaveChangesAsync();
                // listBox.ItemsSource = list;
               // var g = await db.Visits.ToListAsync();
               ///
                var list = await db.Visits.Include(it => it.Subject).Include(it => it.Student)
                    .Include(it =>it.Group).ToListAsync();
                list.ForEach(it => it.Equals(list));   
                await db.SaveChangesAsync();
                listBox.ItemsSource = list;
              

            }
        }
        Groupp aq;
        private async void buttonGroup_Click(object sender, RoutedEventArgs e)
        {

            using (var db = new ApplicationContext())
            { 
            //    aq = new Groupp() { Id = Guid.NewGuid(), Name = groupText.Text };
            //    await db.AddAsync(aq);
            //    await db.SaveChangesAsync();
            //    if (aq != null)
            //    {
            //        button.IsEnabled = true;
            //    }
            //    MessageBox.Show($"Информация успешно добавлена4");

              await  db.Visits.AddAsync(new Visit(){ 
               Id = Guid.NewGuid(),
               Date = visitTextbox.Text,
               Student = new Student() { Id = Guid.NewGuid(), Name = studentsTexbox.Text},
                   Group = new Groupp() { Id = Guid.NewGuid(), Name = groupText.Text },
               Subject = new Subject() { Id = Guid.NewGuid(),Name = subjectTextbox.Text },
              });
                await db.SaveChangesAsync();
                MessageBox.Show($"test trtst");

            }


    }
    }
}
