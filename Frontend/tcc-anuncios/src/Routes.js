import React from 'react'

import { BrowserRouter, Switch, Route } from 'react-router-dom'

import Inicial from './pages/Inicial';
import Login from './pages/Login';
import Home from './pages/Home';
import Anuncio from './pages/Anuncio'
import Cadastrar from './pages/Cadastrar Login';
import MeuPerfil from './pages/Meu perfil';
import RecuperarSenha from './pages/RecuperarSenha'
import Senha from './pages/Senha'
import MeusAnuncios from './pages/Meus anuncios'
import MeusFavoritos from './pages/Meus Favoritos'
import ExcluirAnuncio from './pages/Excluir anuncio'
import InativarAnuncio from './pages/Inativar anuncio'

export default function Routes(){
    return(
        <BrowserRouter>
            <Switch>
                <Route path="/" exact={true} component={Inicial} ></Route>
                <Route path="/Login" component={Login}></Route>
                <Route path="/Home" component={Home}></Route>
                <Route path="/Anuncio" component={Anuncio}></Route>
                <Route path="/Cadastrar" component={Cadastrar}></Route>
                <Route path="/MeuPerfil" component={MeuPerfil}></Route>
                <Route path="/RecuperarSenha" component={RecuperarSenha}></Route>
                <Route path="/Senha" component={Senha}></Route>
                <Route path="/MeusAnuncios" component={MeusAnuncios}></Route>
                <Route path="/MeusFavoritos" component={MeusFavoritos}></Route>
                <Route path="/ExcluirAnuncio" component={ExcluirAnuncio}></Route>
                <Route path="/InativarAnuncio" componet={InativarAnuncio}></Route>
            </Switch>
        </BrowserRouter>
    )
}
