import React from 'react'

import { BrowserRouter, Switch, Route } from 'react-router-dom'

import Inicial from './pages/Inicial';
import Login from './pages/Login';
import Home from './pages/Home';
import Cadastrar from './pages/Cadastrar Login'
import MeuPerfil from './pages/Meu perfil'

export default function Routes(){
    return(
        <BrowserRouter>
            <Switch>
                <Route path="/" exact={true} component={Inicial} ></Route>
                <Route path="/Login" component={Login}></Route>
                <Route path="/Home" component={Home}></Route>
                <Route path="/Cadastrar" component={Cadastrar}></Route>
                <Route path="/MeuPerfil" component={MeuPerfil}></Route>
            </Switch>
        </BrowserRouter>
    )
}
