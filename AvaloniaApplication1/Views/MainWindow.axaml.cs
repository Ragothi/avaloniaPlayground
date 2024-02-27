using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using WeatherApp.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WeatherApp.Views;

public partial class MainWindow : Window{
   
    
    public MainWindow(){
        InitializeComponent();
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
}