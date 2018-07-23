using System.Windows;
using System.Windows.Data;
using ACT.UltraScouter.Config;
using ACT.UltraScouter.Models;
using ACT.UltraScouter.ViewModels;
using FFXIV.Framework.WPF.Views;

namespace ACT.UltraScouter.Views
{
    /// <summary>
    /// MobListView.xaml の相互作用ロジック
    /// </summary>
    public partial class MobListView :
        Window,
        IOverlay
    {
        public MobListView()
        {
            this.InitializeComponent();

            // アクティブにさせないようにする
            this.ToNonActive();

            // ドラッグによる移動を設定する
            this.MouseLeftButtonDown += (s, e) => this.DragMove();

            // 初期状態は透明（非表示）にしておく
            this.Opacity = 0;
        }

        /// <summary>オーバーレイとして表示状態</summary>
        private bool overlayVisible;

        /// <summary>
        /// オーバーレイとして表示状態
        /// </summary>
        public bool OverlayVisible
        {
            get => this.overlayVisible;
            set => this.SetOverlayVisible(ref this.overlayVisible, value, Settings.Instance.Opacity);
        }

        /// <summary>ViewModel</summary>
        public MobListViewModel ViewModel => (MobListViewModel)this.DataContext;

        private void CollectionViewSource_Filter(
            object sender,
            FilterEventArgs e)
            => e.Accepted = (e.Item as MobInfo).Visible;
    }
}
