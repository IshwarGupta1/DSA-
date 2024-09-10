using AbstractFactory;

class Program
{
    private IButton button;
    private ICheckBox checkbox;

    public Program(GUIFactory factory)
    {
        button = factory.button();
        checkbox = factory.checkBox();
    }

    public void Render()
    {
        button.button();
        checkbox.checkBox();
    }

    static void Main(string[] args)
    {
        GUIFactory factory;
        string os = "Windows"; // can be dynamically set
        if (os.Equals("Windows", StringComparison.OrdinalIgnoreCase))
        {
            factory = new WindowsGUIFactory();
        }
        else
        {
            factory = new MacGUIFactory();
        }

        Program app = new Program(factory);
        app.Render();  // Output depends on the chosen platform
    }
}
