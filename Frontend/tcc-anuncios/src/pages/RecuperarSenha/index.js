import React from 'react';
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Inicial/style.css'
import '../RecuperarSenha/style.css'

import Logo from '../../assets/image/Capturar.PNG';

export default function RecuperarSenha(){
    return(
        <div className="vo">

            <div className="cabecalho">
                <div>
                    <Link className="hihi" to="/" ><img class="logo" src={Logo} width="150" height="27px" alt=''/></Link>
                </div>
                <div className="barraPesquisa"></div>
                <div className="meio"></div>
            </div>

            <div className="pai">
                <div className="fi">

                    <label className="v1">Digite o seu CPF e seu RG para recuperar sua senha</label>

                    <div>
                    <label className="mama1">CPF:</label>
                    <input className="v25" type="text" placeholder="CPF"></input>
                    </div>
                    
                    <div>
                    <label className="mama2">RG:</label>
                    <input className="v2" type="text" placeholder="RG"></input>
                    </div>

                    <button className="v3">Verificar</button>
                </div>
            </div>
        </div>
    )
}
