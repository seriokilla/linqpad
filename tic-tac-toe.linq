<Query Kind="Program" />

void Main()
{
	var game = new TicTacToe(4);
	game.Place(0, 0, 1);
	game.Place(0, 1, 1);
	game.Place(0, 2, -1);
	game.Place(1,1,1);
	game.Place(2,2,1);
	game.Place(2,1,1);
	
	game.Place(3,0,1);
	game.Place(0,3,1);
	game.Place(1,2,1);
	game.WhoWon().Dump();
	game.Display();
}

// Define other methods and classes here
// solve if move is a win in tic-tac-toe
class TicTacToe
{
	private int _length;
	private int[][] _RowX;
	private int[][] _RowY;
	
	public TicTacToe(int len)
	{
		_length = len;

		_RowX = new int[_length][];
		_RowY = new int[_length][];
		
		for(var i=0; i<len; i++)
		{
			_RowX[i] = new int[_length];
			_RowY[i] = new int[_length];
		}
	}
	
	public void Place(int x, int y, int player)
	{
		_RowX[x][y] = player;
		_RowY[y][x] = player;
	}
	
	public void Display()
	{
		for(int i=0; i<_length; i++)
		{
			Console.WriteLine(string.Join(" | ", _RowX[i]));
		}
	}
	
	public int WhoWonRow(int[] row)
	{
		for(int i=0; i<_length; i++)
		{
			var sum = _RowX[i].Sum (x => x);
			if (_length == Math.Abs(sum)) return sum < 0 ? -1 : 1;
		}
		return 0;
	}
	
	public int WhoWon()
	{
		// Check all X
		for(int i=0; i<_length; i++)
		{
			var sum = _RowX[i].Sum (x => x);
			if (_length == Math.Abs(sum)) return sum < 0 ? -1 : 1;
		}
		
		// check all y
		for(int j=0; j<_length; j++)
		{
			var sum = _RowY[j].Sum(y => y);
			if (_length == Math.Abs(sum)) return sum < 0 ? -1 : 1;
		}
		
		// check diags
		var diag = 0;
		for(int k=0; k<_length; k++)
		{
			diag += _RowX[k][k]; 
		}
		if (_length == Math.Abs(diag)) return diag < 0 ? -1 : 1;
		
		diag = 0;
		for(int l=0; l<_length; l++)
		{
			diag += _RowX[l][_length-1-l];
		}
		
		if (_length == Math.Abs(diag)) return diag < 0 ? -1 : 1;
		return 0;
	}
}