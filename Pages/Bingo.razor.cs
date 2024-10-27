using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureBingo.Pages
{
    public partial class Bingo
    {
        private const string WachtText = "Even wachten...";
        private const string TrekText = "Trek een nieuw plaatje";

        private bool NoDraw = true;

        private string DrawText = WachtText;

        private List<string> availableOptions = [];

        private List<BingoData> availableNumbers = [];

        private List<BingoData> drawnNumbers = new List<BingoData>();

        private BingoData CurrentPicture;

        private BingoData LastDrawnPicture;

        private bool CanDraw => availableNumbers.Count != 0;

        private string AnimateClass = "";

        protected override async Task OnInitializedAsync()
        {
            // availableNumbers = await BingoService.GetBingoData();
            availableOptions = BingoService.GetBingoOptions();
            DrawText = TrekText;
            NoDraw = !CanDraw;
        }

        private async Task DrawNumber()
        {
            if (!CanDraw)
                return;

            Random r = new Random();
            var drawnNumber = availableNumbers.OrderBy(n => r.Next()).First();

            availableNumbers.Remove(drawnNumber);
            LastDrawnPicture = drawnNumber;
            AnimateClass = "paw-patrol-incoming";
            NoDraw = true;
            DrawText = WachtText;
            await ResetAnimation(5_000);
        }

        private Task ResetAnimation(int ms)
        {
            return Task.Run(() =>
                {
                    System.Threading.Thread.Sleep(ms);
                    AnimateClass = "";
                    CurrentPicture = LastDrawnPicture;
                    drawnNumbers = drawnNumbers.Prepend(CurrentPicture).ToList();
                    NoDraw = !CanDraw;
                    DrawText = TrekText;
                });
        }

        private async Task OnOptionChanged(Microsoft.AspNetCore.Components.ChangeEventArgs e)
        {
            availableNumbers = await BingoService.GetBingoData((string)e.Value);
            NoDraw = !CanDraw;
        }
    }
}