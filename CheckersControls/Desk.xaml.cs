using System;
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
using Models.Checkers;
using Color = System.Drawing.Color;

namespace CheckersControls
{
    /// <summary>
    /// Логика взаимодействия для Desk.xaml
    /// </summary>
    public sealed partial class Desk : UserControl
    {
        public Board Board { get; set; }

        public IEnumerable<char> Numbers => Enumerable
            .Range(BoardGrid.Columns, 1)
            .ToList()
            .Select(s => (char)(s + 30));
        
        public IEnumerable<char> Letters => 
            Enumerable
                .Range(1, BoardGrid.Rows)
                .ToList()
                .Select(s => (char) (s + 40));
        
        public Desk(Board board)
        {
            Board = board;
            InitializeComponent();
            BoardGrid.Rows = Board.GetDimensions().Item1;
            BoardGrid.Columns = Board.GetDimensions().Item2;

            for (var i = 0; i < BoardGrid.Columns; i++)
                for (var j = 0; j < BoardGrid.Rows; j++)
                    AddCell(j, i);
            
            BoardGrid.UpdateLayout();
        }

        private void AddCell(int x, int y)
        {
            var cell = new Cell(Board,x,y,(x + y) % 2 == 0 ? Color.Black : Color.White);

            Grid.SetColumn(cell, y);
            Grid.SetRow(cell, x);

            if (!BoardGrid.Children.Contains(cell))
                BoardGrid.Children.Add(cell);
        }
    }
}
