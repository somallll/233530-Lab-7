using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace CricketTeamManager
{
    public partial class MainWindow : Window
    {
        // ObservableCollection to dynamically update ListBox
        public ObservableCollection<string> Players { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Players = new ObservableCollection<string>(); // Initialize collection
            PlayersListBox.ItemsSource = Players;         // Bind to ListBox
        }

        // Add Player Button Click Event
        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            string playerName = PlayerNameTextBox.Text.Trim(); // Get trimmed input

            // Validation for empty or duplicate names
            if (string.IsNullOrWhiteSpace(playerName))
            {
                MessageBox.Show("Player name cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Players.Contains(playerName))
            {
                MessageBox.Show("This player is already in the roster.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Add to roster
            Players.Add(playerName);
            MessageBox.Show($"Player '{playerName}' added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear the TextBox
            PlayerNameTextBox.Clear();
        }

        // Remove Player Button Click Event
        private void RemovePlayer_Click(object sender, RoutedEventArgs e)
        {
            if (PlayersListBox.SelectedItem is string selectedPlayer)
            {
                // Remove player
                Players.Remove(selectedPlayer);
                MessageBox.Show($"Player '{selectedPlayer}' removed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a player to remove.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
