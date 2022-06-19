using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CheckersControls;

public partial class Checker : UserControl
{
    public Models.Checkers.Checker Model { get; set; }
    
    public Checker()
    {
        InitializeComponent();
    }
    
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (e.LeftButton != MouseButtonState.Pressed) return;
        
        
        var data = new DataObject();
        data.SetData("Object", this);
        
        DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
    }
    
    protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
    {
        base.OnGiveFeedback(e);
        
        if (e.Effects.HasFlag(DragDropEffects.Move))
            Mouse.SetCursor(Cursors.Pen);
        else
            Mouse.SetCursor(Cursors.No);
        
        e.Handled = true;
    }
}