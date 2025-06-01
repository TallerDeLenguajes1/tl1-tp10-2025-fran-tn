namespace EspacioTarea;

public class Tarea{

    public int userId
    {
        get;set;
    }

    public int id
    {
        get;set;
    }

    public string title
    {
        get;set;
    }

    public bool completed
    {
        get;set;
    }
}
/*
    public int UserId
    {
        get => userId;
    }

    public int Id
    {
        get => id;
    }

    public string Title
    {
        get => title;
    }

    public bool Completed
    {
        get => completed;
    }

    public void cargar(int cargarId, int cargarUser, string cargarTitle, bool cargarCompleted)
    {
        id = cargarId;
        userId = cargarUser;
        title = cargarTitle;
        completed = cargarCompleted;
    }
}
*/