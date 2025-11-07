*Task1: Re-Skin: Changed skin, result is in Game Scene.
*Task2+3: Create a new GamePlay located in Scene Task2_3.
  Introduce:
    - The player clicks to select a tile (fish) on the board.
    - The tile is moved to the BottomBar.
    - When there are 3 tiles of the same type in the BottomBar (at any position), they will be cleared.
    - The remaining tiles in the BottomBar will be pushed to the left.
    - If the BottomBar is full and not cleared, the player loses.
    - If the entire board is cleared, the player wins.
    - There is a Time Attack mode with a large, clear countdown timer displayed at the top of the screen.

  Hierarchy in Unity:
    - GridBoard: where fish tiles spawn.
    - BottomBar: contains Slots for tiles to fall.
    - Slots: each Slot is a Transform with a SpriteRenderer (square).
    - TimeAttackPanel: UI Text or TextMeshPro to display time.

  Code Structure: (Folder Task23Gameplay)
    Controllers: Control the logic of gameplay.
    UI: UI Management
    *Specifically:
      TileNew.cs: Represents a tile on the GridBoard.
      TileItemNew.cs: Manage tile information (Type, Sprite).
      TileManagerNew.cs: GridBoard Management.
      BottomBarNew.cs: Manage Slots and tiles in BottomBar.
      UITimeAttackPanelNew.cs: Manage countdown timer.

  Gameplay Flow:
    - Player clicks tile → tile jumps to BottomBar.
    - If there are ≥ 3 tiles of the same type → clear, the remaining tiles are pushed to the left.
    - If BottomBar is full and cannot be cleared → lose.
    - If GridBoard runs out of tiles → win.
    - In Time Attack mode, if time runs out → lose.

  + Development direction:
    - Add animation when tile moves from GridBoard to BottomBar.
    - Add sound effect when clear.
    - Add more game modes (Classic, Endless…).
