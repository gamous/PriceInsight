using System;
using Dalamud.Interface;
using ImGuiNET;

namespace PriceInsight; 

class ConfigUI : IDisposable {
    private readonly Configuration configuration;

    private bool settingsVisible = false;

    public bool SettingsVisible {
        get => settingsVisible;
        set => settingsVisible = value;
    }

    public ConfigUI(Configuration configuration) {
        this.configuration = configuration;
    }

    public void Dispose() {
    }

    public void Draw() {
        if (!SettingsVisible) {
            return;
        }

        ImGui.SetNextWindowSize(ImGuiHelpers.ScaledVector2(320, 170), ImGuiCond.Always);
        if (ImGui.Begin("Price Insight Config", ref settingsVisible,
                ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)) {
            var configValue = configuration.ShowDatacenter;
            if (ImGui.Checkbox("显示大区价格", ref configValue)) {
                configuration.ShowDatacenter = configValue;
                configuration.Save();
            }

            configValue = configuration.ShowWorld;
            if (ImGui.Checkbox("显示原始服务器价格", ref configValue)) {
                configuration.ShowWorld = configValue;
                configuration.Save();
            }

            configValue = configuration.ShowMostRecentPurchase;
            if (ImGui.Checkbox("显示最近购买价格", ref configValue)) {
                configuration.ShowMostRecentPurchase = configValue;
                configuration.Save();
            }

            configValue = configuration.ShowMostRecentPurchaseWorld;
            if (ImGui.Checkbox("显示原始服务器最近购买价格", ref configValue)) {
                configuration.ShowMostRecentPurchaseWorld = configValue;
                configuration.Save();
            }

            configValue = configuration.IgnoreOldData;
            if (ImGui.Checkbox("忽略一个月以前的数据", ref configValue)) {
                configuration.IgnoreOldData = configValue;
                configuration.Save();
            }
        }

        ImGui.End();
    }
}