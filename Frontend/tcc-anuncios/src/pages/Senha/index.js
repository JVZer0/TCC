import React, { useState, useEffect } from 'react';
import { Link, useHistory } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Inicial/style.css'
import '../Senha/style.css'

import Logo from '../../assets/image/Capturar.PNG';

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();

export default function Senha(props){

    const [senha, setSenha] = useState(props.location.state);

    return(
        <div className="in">
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to="/" ><img class="logo" src={Logo} width="180" height="34px" alt=''/></Link>
                </div>
                <div className="barraPesquisa"></div>
                <div className="meio"></div>
            </div>

            <div className="ini">
                <div>
                    <label className="su">Sua senha é:&nbsp;</label>
                    <b className="su">{senha}</b>
                </div>
                <Link to="/Login"><button className="botox1">Fazer login</button></Link>
            </div>
        </div>
    )
}
