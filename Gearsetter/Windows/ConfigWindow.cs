using Dalamud.Bindings.ImGui;
using Dalamud.Plugin;
using LLib.ImGui;

namespace Gearsetter.Windows;

internal sealed class ConfigWindow : LWindow
{
    private readonly IDalamudPluginInterface _pluginInterface;
    private readonly Configuration _configuration;

    public ConfigWindow(IDalamudPluginInterface pluginInterface, Configuration configuration)
        : base("Gearsetter - 設定###GearsetterConfig", ImGuiWindowFlags.AlwaysAutoResize)
    {
        _pluginInterface = pluginInterface;
        _configuration = configuration;
    }

    public override void DrawContent()
    {
        bool showRecommendationsWhenEnteringGcArea = _configuration.ShowRecommendationsWhenEnteringGcArea;
        if (ImGui.Checkbox("進入大國防聯軍區域時顯示推薦裝備",
                ref showRecommendationsWhenEnteringGcArea))
        {
            _configuration.ShowRecommendationsWhenEnteringGcArea = showRecommendationsWhenEnteringGcArea;
            _pluginInterface.SavePluginConfig(_configuration);
        }
    }
}
