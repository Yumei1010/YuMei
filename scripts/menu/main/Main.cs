using Godot;

namespace GFrameworkTemplate.scripts.menu.main;

public partial class Main : Node
{
    private Vector2I _size = new(128, 192);

    public override void _Ready()
    {
        var w = GetWindow();
        w.Mode = Window.ModeEnum.Windowed;
        w.Borderless = true;
        w.AlwaysOnTop = true;
        w.Transparent = true;
        w.Unresizable = true;
        w.MinSize = _size;
        w.MaxSize = _size;
        w.Size = _size;
        GetViewport().TransparentBg = true;

        var indicator = GetNode<StatusIndicator>("StatusIndicator");
        indicator.Icon = MakePlaceholderIcon();
        indicator.Menu = GetNode<PopupMenu>("PopupMenu").GetPath();

        GetNode<PopupMenu>("PopupMenu").IdPressed += OnPopupIdPressed;
    }

    public override void _Process(double delta)
    {
        var w = GetWindow();
        if (w.Mode != Window.ModeEnum.Windowed)
            w.Mode = Window.ModeEnum.Windowed;
        if (!w.Borderless)
            w.Borderless = true;
        if (w.Position == new Vector2I(-32000, -32000) || w.Size != _size)
            w.Size = _size;
    }

    private static ImageTexture MakePlaceholderIcon()
    {
        var img = Image.CreateEmpty(32, 32, false, Image.Format.Rgba8);
        img.Fill(new Color(0.4f, 0.7f, 1f, 1f));
        return ImageTexture.CreateFromImage(img);
    }

    private void OnPopupIdPressed(long id)
    {
        if (id == 0)
            GetTree().Quit();
    }
}