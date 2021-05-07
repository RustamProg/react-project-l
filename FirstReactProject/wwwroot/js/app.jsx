class UsersList extends React.Component{
    constructor(props) {
        super(props);
        this.state = {
          users: [],  
        };
    }
    
    componentDidMount(){
        var xhr = new XMLHttpRequest();
        xhr.open("get", this.props.apiUrl, true);
        xhr.onload = function (){
            var data = JSON.parse(xhr.responseText);
            this.setState({users: data})
        }.bind(this);
        xhr.send();
    }
    
    render(){
        return (
            <ul>
                {this.state.users.map(user => (
                    <li key={user.id}>
                        {user.firstName} - {user.lastName}
                    </li>
                ))}
            </ul>
        );
    }
}


ReactDOM.render(
    <UsersList apiUrl="/users/users_list"/>,
    document.getElementById("content")
);