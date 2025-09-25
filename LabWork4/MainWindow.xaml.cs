using LabWork4.Data;
using LabWork4.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabWork4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly FilmInfoContext filmInfoContext;
        public MainWindow()
        {
            InitializeComponent();

            filmInfoContext = new FilmInfoContext();

            var filmsWithGenres = from film in filmInfoContext.Films.Include(f => f.Genre)
                                  select new FilmViewModel
                                  {
                                      FilmId = film.FilmId,
                                      FilmName = film.FilmName,
                                      AgeRating = film.AgeRating,
                                      Rating = film.Rating,
                                      GenreName = film.Genre.GenreName
                                  };
            DataGrid.ItemsSource = filmsWithGenres.ToList();


        }

        private void FilmAddButton_Click(object sender, RoutedEventArgs e)
        {
            string filmName = FilmTextBox.Text;
            Genre selectedGenre = (Genre)GenreComboBox.SelectedValue;
            int selectedAgeRating = (int)AgeRatingComboBox.SelectedValue;
            if (!decimal.TryParse(RatingTextBox.Text, out decimal rating)) 
            {
                MessageBox.Show("Пожалуйста, введите корректный рейтинг!");
                return;
            }

            var newFilm = new Film
            {
                FilmName = filmName,
                Genre = selectedGenre,
                AgeRating = selectedAgeRating.ToString(),
                Rating = rating
            };
            try
            {
                filmInfoContext.Films.Add(newFilm);
                filmInfoContext.SaveChanges();
                MessageBox.Show("Фильм успешно был добавлен!");
                FilmTextBox.Clear();
                GenreComboBox.SelectedIndex = -1;
                AgeRatingComboBox.SelectedIndex = -1;
                RatingTextBox.Clear();
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка при добавлении фильма:{ex.Message}");
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}