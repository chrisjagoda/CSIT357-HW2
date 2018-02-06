# A* *Pathfinding #

This is an A* *pathfinding algorithm implemented on a grid/heightmap with perlin noise generated height values.

Each node in the grid travels only horizontally and vertically with the distance between each node being 1 unit.

The heuristic for the AStar is the difference in height between two nodes, with a greater difference equating to a steeper slope, and a lower difference equating to a more level surface.

Output is displayed on a colored height map in the console.

Height and width may be adjusted to set the size of the grid and intensity controls the degree of the slopes, 100+ range being ideal for seeing the effects of the heuristic.
